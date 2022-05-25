using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YadBeYadServerBL.Models;

namespace YadBeYadServer.Controllers
{
    [Route("YadBeYadAPI")]//achi
    [ApiController]
    public class YadBeYadController : ControllerBase
    {
        #region Add connection to the db context using dependency injection
        YadBeYadDBContext context;
        public YadBeYadController(YadBeYadDBContext context)
        {
            this.context = context;
        }
        #endregion
        
        [Route("Login")]
        [HttpGet]
        public User Login([FromQuery] string email, [FromQuery] string pass)
        {
            User user = context.Login(email, pass);

            //Check user name and password
            if (user != null)
            {
                HttpContext.Session.SetObject("theUser",user);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                return user;
            }
            else
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }


        // Sign Up for Client!!!

        [Route("SignUp")]
        [HttpPost]

        public bool SignUp([FromBody] User user)
        {
            bool isSuccess = context.SignUp(user);

            if (isSuccess)//the sign up worked
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return isSuccess;
            }
            else//the sign up failed
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return isSuccess;
            }
        }
       

        // a function that checks that the inserted email, phone number and user name are unique


        [Route("CheckUniqueness")]
        [HttpGet]

        public bool CheckUniqueness([FromQuery] string email, [FromQuery] string userName)
        {
            bool isUnique = this.context.CheckUniqueness(email, userName);

            if (isUnique)//the email and the user name are unique
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return isUnique;
            }
            else//one or both are not unique
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return isUnique;
            }
        }
        [Route("GetAttractions")]
        [HttpGet]

        public List<Attraction> GetAttractions()
        {
            
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return context.GetAttractions();
           
        }
        [Route("GetReviewsByUser")]
        [HttpGet]
        public List<Review> GetReviewsByUser([FromQuery] int userId)
        {
            User user = HttpContext.Session.GetObject<User>("theUser");

            if (user != null)//the sign up worked
            {

                List<Review> l = context.GetReviewsByUser(userId);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return l;
            }
            else//the user not loggedIn in
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
        [Route("GetRatesByUser")]
        [HttpGet]
        public List<Rate> GetRatesByUser([FromQuery] int userId)
        {
            User user = HttpContext.Session.GetObject<User>("theUser");

            if (user != null)//the sign up worked
            {

                List<Rate> l = context.GetRatesByUser(userId);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return l;
            }
            else//the user not loggedIn in
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
        [Route("GetFavoritesByUser")]
        [HttpGet]
        public List<Favorite> GetFavoritesByUser([FromQuery] int userId)
        {
            User user = HttpContext.Session.GetObject<User>("theUser");

            if (user != null)//the sign up worked
            {

                List<Favorite> l = context.GetFavoritesByUser(userId);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return l;
            }
            else//the user not loggedIn in
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("AddFavorite")]
        [HttpPost]

        public Favorite AddFavorite([FromBody] Favorite favorite)
        {

            User user = HttpContext.Session.GetObject<User>("theUser");

            if (user!=null)//the sign up worked
            {

                Favorite f = context.AddFavorite(favorite);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return f;
            }
            else//the user not loggedIn in
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("CancelFavorite")]
        [HttpPost]

        public bool CancelFavorite([FromBody] Favorite favorite)
        {

            User user = HttpContext.Session.GetObject<User>("theUser");

            if (user != null)//the sign up worked
            {
                bool isSuccess = context.CancelFavorite(favorite.FavoriteId);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return isSuccess;
            }
            else//the user not loggedIn in
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return false;
            }
        }



    }

}
