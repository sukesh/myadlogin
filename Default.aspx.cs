using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Security.Permissions;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)]

namespace ADLogin
{
    public partial class Default : System.Web.UI.Page
    {
        public DirectorySearcher dirSearch = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetUserInformation(string username, string passowrd, string domain)
        {
            SearchResult rs = null;
            if (txtSearchUser.Text.Trim().IndexOf("@") > 0)
                rs = SearchUserByEmail(GetDirectorySearcher(username, passowrd, domain), txtSearchUser.Text.Trim());
            else
                rs = SearchUserByUserName(GetDirectorySearcher(username, passowrd, domain), txtSearchUser.Text.Trim());

            if (rs != null)
            {
                ShowUserInformation(rs);
            }
            else
            {
                lblMessage.Text = "User not found!!!";
            }
        }

        private void ShowUserInformation(SearchResult rs)
        {
            lblMessage.Text = "<br/>";  
            if (rs.GetDirectoryEntry().Properties["samaccountname"].Value != null)
                lblMessage.Text += "<br/>Username : " + rs.GetDirectoryEntry().Properties["samaccountname"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["givenName"].Value != null)
                lblMessage.Text += "<br/>First Name : " + rs.GetDirectoryEntry().Properties["givenName"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["initials"].Value != null)
                lblMessage.Text += "<br/>Middle Name : " + string.Empty;
            try
            {
                lblMessage.Text += "<br/>Middle Name : " + rs.GetDirectoryEntry().Properties["initials"].Value.ToString();
            }
            catch (Exception)
            {
                lblMessage.Text += "<br/>Middle Name : " + string.Empty;
            }
            if (rs.GetDirectoryEntry().Properties["sn"].Value != null)
                lblMessage.Text += "<br/>Last Name : " + rs.GetDirectoryEntry().Properties["sn"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["mail"].Value != null)
                lblMessage.Text += "<br/>Email ID : " + rs.GetDirectoryEntry().Properties["mail"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["title"].Value != null)
                lblMessage.Text += "<br/>Title : " + rs.GetDirectoryEntry().Properties["title"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["company"].Value != null)
                lblMessage.Text += "<br/>Company : " + rs.GetDirectoryEntry().Properties["company"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["l"].Value != null)
                lblMessage.Text += "<br/>City : " + rs.GetDirectoryEntry().Properties["l"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["st"].Value != null)
                lblMessage.Text += "<br/>State : " + rs.GetDirectoryEntry().Properties["st"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["co"].Value != null)
                lblMessage.Text += "<br/>Country : " + rs.GetDirectoryEntry().Properties["co"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["postalCode"].Value != null)
                lblMessage.Text += "<br/>Postal Code : " + rs.GetDirectoryEntry().Properties["postalCode"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["telephoneNumber"].Value != null)
                lblMessage.Text += "<br/>Telephone No. : " + rs.GetDirectoryEntry().Properties["telephoneNumber"].Value.ToString();

        }

        private DirectorySearcher GetDirectorySearcher(string username, string passowrd, string domain)
        {
            if (dirSearch == null)
            {
                try
                {
                    dirSearch = new DirectorySearcher(
                        new DirectoryEntry("LDAP://" + domain, username, passowrd));
                }
                catch (DirectoryServicesCOMException e)
                {
                    lblMessage.Text = "Connection Creditial is Wrong!!!, please Check.";
                    e.Message.ToString();
                }
                return dirSearch;
            }
            else
            {
                return dirSearch;
            }
        }

        private SearchResult SearchUserByUserName(DirectorySearcher ds, string username)
        {
            ds.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(samaccountname=" + username + "))";

            ds.SearchScope = SearchScope.Subtree;
            ds.ServerTimeLimit = TimeSpan.FromSeconds(90);

            SearchResult userObject = ds.FindOne();

            if (userObject != null)
                return userObject;
            else
                return null;
        }

        private SearchResult SearchUserByEmail(DirectorySearcher ds, string email)
        {
            ds.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(mail=" + email + "))";

            ds.SearchScope = SearchScope.Subtree;
            ds.ServerTimeLimit = TimeSpan.FromSeconds(90);

            SearchResult userObject = ds.FindOne();

            if (userObject != null)
                return userObject;
            else
                return null;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            if (txtUsername.Text.Trim().Length != 0 && txtPassword.Text.Trim().Length != 0 && txtAddress.Text.Trim().Length != 0 && txtSearchUser.Text.Trim().Length != 0)
            {
                GetUserInformation(txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtAddress.Text.Trim());
            }
            else
            {
                lblMessage.Text = "Please enter all required inputs.";
            }
        }
    }
}