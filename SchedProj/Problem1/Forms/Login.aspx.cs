/*
 * 
 * Secure Access (DB Users / Table UserInfo):
 * user5 / user5 / MD5 / 0A791842F52A0ACFBB3A783378C066B8
 * user6 / user6 / MD5 / AFFEC3B64CF90492377A8114C86FC093
 * user7 / user7 / MD5 / 3E0469FB134991F8F75A2760E409C6ED
 * user8 / user8 / SHA1 / A14C955BDA572B817DECCC3A2135CC5F2518C1D3

Secure XML:
user3 / pass3
user4 / pass4
Dave / Dave
Judy / Judy
SHA1 / SHA1

unSecure XML:
user1 / pass1
user2 / pass2
UnSecure / UnSecure
Judy1 / Judy1

 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.OleDb;

namespace SWE346.Module5.Problem1.Forms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["showhash"].Equals("true"))
                {
                    // enable hash calculator
                    TextBox1.Visible = true;
                    TextBox2.Visible = true;
                    Button3.Visible = true;
                    Button2.Visible = true;
                    Label4.Visible = true;
                }
            }
            catch (Exception ex) 
            { }
        }

        protected bool AuthenticateUser(string uName, string uPass)
        {
            bool founduser, foundpassword;
            string colValue, hashPasswd = "", hashType = "";
            if (RadioButtonList1.SelectedIndex == 0) // open text password
            {
                foreach (DataTable myTable1 in UserAuthList().Tables)
                {
                    //TextBox3.Text+="Table '" + myTable.ToString() + "'  \n";

                    foreach (DataRow r in myTable1.Rows)
                    {
                        founduser = foundpassword = false;
                        foreach (DataColumn c in myTable1.Columns)
                        {
                            colValue = r[c].ToString();
                            //TextBox3.Text += c.ColumnName + " '" + r[c] + "' ";
                            if (c.ColumnName.Equals("username") && r[c].Equals(uName))
                                founduser = true;
                            else if (c.ColumnName.Equals("password") && r[c].Equals(uPass))
                                foundpassword = true;
                        }
                        if (founduser && foundpassword)
                            return true;
                    }
                }
            } // end if open password XML
            else if (RadioButtonList1.SelectedIndex == 1) // hashed password
            {
                foreach (DataTable myTable in UserAuthListSecure().Tables)
                {
                    //TextBox3.Text+="Table '" + myTable.ToString() + "'  \n";

                    foreach (DataRow r in myTable.Rows)
                    {
                        hashPasswd = hashType = "";
                        founduser = foundpassword = false;
                        foreach (DataColumn c in myTable.Columns)
                        {
                            colValue = r[c].ToString();

                            //TextBox3.Text += c.ColumnName + " '" + r[c] + "' ";
                            if (c.ColumnName.Equals("username") && r[c].Equals(uName))
                                founduser = true;
                            else if (c.ColumnName.Equals("password"))
                                hashPasswd = r[c].ToString();
                            else if (c.ColumnName.Equals("type"))
                                hashType = r[c].ToString();
                        } // for each DataColumn
                        foundpassword = (hashPasswd == FormsAuthentication.
                            HashPasswordForStoringInConfigFile(uPass, hashType));
                        if (founduser && foundpassword)
                            return true;
                    } // for each DataRow
                } // for each DataTable
            } // end if secure XML
            else if (RadioButtonList1.SelectedIndex == 2) // secure SQL DB
            {
                //string mySQLDB = @"D:\Documents and Settings\212039854\My Documents\Docs\Champlain College\SWE-346-51\Week10\Login\assignment.solution\Problem1\Users.mdb";
                //Server.MapPath("~\App_Data");
                string mySQLDB = Server.MapPath(@"~\App_Data\Users.mdb");
                //string mySQLDB = @"C:\Users\Dave\Documents\git_tutorial\work\SchedProj\Problem1\App_Data\Users.mdb";
                String CONNECTION_STRING = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+mySQLDB+";User Id=;Password=;";
                DataSet ds = new DataSet();
                using (OleDbConnection oConnection = new OleDbConnection(CONNECTION_STRING))
                {
                    OleDbDataAdapter oDataAdapter = new OleDbDataAdapter
                        ("Select * from UserInfo where username='" + uName + "'", oConnection);
                    OleDbCommandBuilder oCommandBuilder =
                        new OleDbCommandBuilder(oDataAdapter);
                    oCommandBuilder.QuotePrefix = "[";
                    oCommandBuilder.QuoteSuffix = "]";
                    try
                    {
                        oConnection.Open();
                        oDataAdapter.Fill(ds, "UserInfo");
                        for (int i = 0; i < ds.Tables["UserInfo"].Rows.Count; i++)
                        {
                            DataRow row = ds.Tables["UserInfo"].Rows[i];
                            hashType = row.ItemArray[2].ToString();
                            hashPasswd = FormsAuthentication.
                                HashPasswordForStoringInConfigFile(uPass, hashType);
                            if (row.ItemArray[0].ToString().Equals(uName) &&
                                hashPasswd.Equals(row.ItemArray[1].ToString()))
                                return true;
                        }
                    }
                    catch (OleDbException e)
                    {
                        Response.Write(e.ToString());                        
                    }
                    finally
                    {
                        oConnection.Close();
                    }
                } // end using clause
            }
            return false;
        } // AuthenticateUser

        protected DataSet UserAuthList () {
            DataSet ds = new DataSet();
            //string myXMLfile = @"D:\Documents and Settings\212039854\My Documents\Docs\Champlain College\SWE-346-51\Week10\Login\assignment.solution\Problem1\Users.xml";
            //string myXMLfile = @"Problem1\Users.xml";
            string myXMLfile = @"C:\HCU-6W2PQM1\D\Documents and Settings\212039854\My Documents\Programs-C#\SWE-346-51\Week10\Login\assignment.solution\Problem1\Users.xml";
            try
            {
                ds.ReadXml(myXMLfile);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            return ds;
        }

        protected DataSet UserAuthListSecure () {
            string myXMLfile = @"C:\HCU-6W2PQM1\D\Documents and Settings\212039854\My Documents\Programs-C#\SWE-346-51\Week10\Login\assignment.solution\Problem1\UsersSecure.xml";
            //string myXMLfile = @"Problem1\UsersSecure.xml";
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(myXMLfile);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            return ds;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = FormsAuthentication.HashPasswordForStoringInConfigFile
                (TextBox2.Text, "MD5");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = FormsAuthentication.HashPasswordForStoringInConfigFile
                (TextBox2.Text, "SHA1");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uName = txtUserName.Text;
            string uPass = txtPassword.Text;
            if (AuthenticateUser(uName, uPass))
            {
                Session["LoginUser"] = uName;
                FormsAuthentication.RedirectFromLoginPage(uName, false);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
