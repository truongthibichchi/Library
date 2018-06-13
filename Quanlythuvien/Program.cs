using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlythuvien.Forms;
using System.Data.SqlLocalDb;
using System.Resources;
using System.Reflection;
using System.Security.Principal;


using System.IO;
using System.Data.SqlClient;
using Quanlythuvien.Properties;

namespace Quanlythuvien
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            ISqlLocalDbApi localDB = new SqlLocalDbApiWrapper();

            if (!localDB.IsLocalDBInstalled())
            {
                MessageBox.Show("Máy tính của bạn phải cài đặt SQL Server LocalDB hoặc phiên bản Express để có thể sử dụng phần mềm.");
                return;
            }

            string uuid = "nhom7-928cf731-171f-464f-aa55-24e814eeb224";

            ISqlLocalDbProvider provider = new SqlLocalDbProvider();

            IList<ISqlLocalDbInstanceInfo> instances = provider.GetInstances();

            bool flag = false;

            foreach (ISqlLocalDbInstanceInfo instanceInfo in instances)
            {
                if(instanceInfo.Name == uuid)
                {
                    flag = true;
                    break;
                }
            }

            if(!flag)
            {
                WaitForm frm = new WaitForm();
                frm.Show();
                ISqlLocalDbInstance instance = provider.CreateInstance(uuid);
                instance.Start();

                try
                {
                    if (IsCurrentUserAdmin())
                    {
                        
                    }
                    try
                    {
                        using (SqlConnection connection = instance.CreateConnection())
                        {
                            connection.Open();
                            try
                            {
                                string scriptText = Resources.script.ToString();
                                string[] splitter = new string[] { "\r\nGO\r\n" };
                                string[] commandTexts = scriptText.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string commandText in commandTexts)
                                {
                                    using (SqlCommand command = new SqlCommand(commandText, connection))
                                    {
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    finally
                    {
                        if (IsCurrentUserAdmin())
                        {
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    instance.Stop();
                }

                frm.Close();
            }
            else
            {
                ISqlLocalDbInstance instance = provider.GetInstance(uuid);
            }

            Global.connstring = @"Data Source=(LocalDB)\nhom7-928cf731-171f-464f-aa55-24e814eeb224;Initial Catalog=QUANLYTHUVIEN_Nhom7_14521100_15520048_15520062_15520115;Integrated Security=True";

            Application.Run(new frmDangNhap());
        }
        private static bool IsCurrentUserAdmin()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
    }
}