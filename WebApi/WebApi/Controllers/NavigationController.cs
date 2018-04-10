using System;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class NavigationController : Controller
    {
        #region Actions       

        /// <summary>
        /// Post action for navigation instructions.
        /// </summary>
        /// <returns></returns>    
        [ValidateInput(false)]
        public ActionResult GetDistance(DirectionsModel input)
        {
            return Json(new { result = this.CalculateDistance(input.Directions) });           
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates number of blocks away destination is based on given directions
        /// </summary>
        /// <param name="directions">A string representings directions to destination.</param>
        /// <returns>Number of blocks away destination is, or -1 if error.</returns>
        private int CalculateDistance(string directions)
        {
            if(directions == null || directions.Trim() == "")
            {
                return -1;
            }

            int x = 0;
            int y = 0;
            int currentDirection = 0;
            string[] items = directions.Split(',');

            foreach (string item in items)
            {
                //parse direction and update our current direction
                //0 = north, 1 = east, 2 = south, 3 = west
                string step = item.ToUpper().Trim();
                char direction = step[0];

                switch (direction)
                {
                    case 'L':
                        currentDirection--;
                        break;
                    case 'R':
                        currentDirection++;
                        break;
                    default:
                        return -1;
                }

                if(currentDirection == -1)
                {
                    currentDirection = 3;
                }

                if(currentDirection == 4)
                {
                    currentDirection = 0;
                }

                //parse units to travel, and add to proper coordinate
                int units;
                if(!int.TryParse(step.Substring(1), out units))
                {
                    return -1;
                }

                if(units < 1)
                {
                    return -1;
                }

                switch(currentDirection)
                {
                    case 0:
                        y += units;
                        break;
                    case 1:
                        x += units;
                        break;
                    case 2:
                        y -= units;
                        break;
                    case 3:
                        x -= units;
                        break;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        #endregion
    }
}
