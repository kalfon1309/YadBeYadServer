﻿ using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadBeYadServerBL.Models
{
    partial class YadBeYadDBContext : DbContext
    {
        public List<Attraction> GetAttractions()
        {
            List<Attraction> attractions = this.Attractions.Include(att=>att.Rates).Include(att=>att.Reviews).ThenInclude(r=>r.User).ToList<Attraction>();
            return attractions;
        }

        public User Login(string email, string pswd)
        {
            User user = this.Users
                .Include(us => us.Rates).ThenInclude(f => f.Attraction)
                .Include(uc => uc.Reviews).ThenInclude(f => f.Attraction)
                .Include(uc => uc.Favorites).ThenInclude(f => f.Attraction)
                .Where(u => u.Email == email && u.Pass == pswd).FirstOrDefault();

            return user;
        }

        // Sign Up for Client

        public bool SignUp(User u)
        {
          
            if(u != null)
            {
                this.Users.Add(u);
                this.SaveChanges();
                return true;
            }

            return false;

        }



        // a function that checks that the inserted email and user name are unique

        public bool CheckUniqueness(string email, string userName)
        {
            User user = this.Users.Where(u => u.Email == email || u.UserName == userName).FirstOrDefault();

            if (user == null)//the email and the user name are unique
            {
                return true;
            }
            else//one or both are not unique
            {
                return false;
            }
        }


        public Favorite AddFavorite(Favorite favorite)
        {
            Favorite toReActivate = this.Favorites.Where(f => f.UserId == favorite.User.UserId && f.AttractionId == favorite.Attraction.AttractionId).FirstOrDefault();
            if(toReActivate != null)
            {
                toReActivate.IsActive = true;
                this.Entry(toReActivate).State = EntityState.Modified;
                this.SaveChanges();
                return toReActivate;
            }
            else
            {
                this.Entry(favorite).State = EntityState.Added;
                this.Entry(favorite.Attraction).State = EntityState.Unchanged;
                this.Entry(favorite.User).State = EntityState.Unchanged;

                this.SaveChanges();
                Favorite toReturn = this.Favorites.Where(f => f.UserId == favorite.User.UserId && f.AttractionId == favorite.Attraction.AttractionId).FirstOrDefault();
                return toReturn;
            }
            
        }


        public bool CancelFavorite(int favoriteId)
        {

            Favorite toCancel = this.Favorites.Where(f => f.FavoriteId == favoriteId).FirstOrDefault();

            if(toCancel != null)
            {
                toCancel.IsActive = false;
                this.Entry(toCancel).State = EntityState.Modified;
                this.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}
