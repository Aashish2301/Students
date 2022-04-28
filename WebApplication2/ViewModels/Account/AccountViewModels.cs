using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Account;
using WebApplication2.Models.General;

namespace WebApplication2.ViewModels.Account
{
    public class AccountViewModels
    {

           

        public static List<SelectListItem> GetAllRoles(int roleId )
        {
            List<SelectListItem> roles = new List<SelectListItem>();


            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionStrings()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RolesGetRolesByRoleId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();


                    cmd.Parameters.AddWithValue("@RoleId ", roleId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SelectListItem item = new SelectListItem();
                        item.Value = reader["RoleName"].ToString();
                        item.Text = reader["RoleName"].ToString();

                        roles.Add(item);

                    }
                }
            }

            return roles;
        }

        
        //public static List<UserModel> GetAllUsers()
        //{
        //    List<UserModel> users = new List<UserModel>();
        //    using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionStrings()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("usp_UsersGetAllUsers", conn))
        //        {
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            conn.Open();


        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                UserModel user = new UserModel();
        //                user.UserId = Convert.ToInt32(reader["UserId"]);

        //                user.UserName = reader["UserName"].ToString();
        //                user.FullName = reader["FullName"].ToString();
        //                user.Email = reader["Email"].ToString();
        //                user.Gender = reader["Gender"].ToString();
        //                user.MobileNo = reader["MobileNo"].ToString();
        //                user.IsActive = Convert.IsDBNull(reader["IsActive"]);
        //                users.Add(user);
        //            }
        //        }
        //    }
        //    return users;


        //}
    }
    }
