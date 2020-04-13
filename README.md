## Web API Router with authentication through JWT Token and Active Directory
This is one of my proojects that was made from the scratch. 
The main idea is to create a proxy Api that will help you control the API service responses according to the User rights. 
Each user has a set of rights consisting of Module, Object and Operators.
* ``Module`` represents the service the user can access to
* ``Object`` refers to the objects each service deals with.
* ``Operators`` are actions each user can do with the object.

All the actions names in the proxy controller should correspond to the action names in the original API's and should be provided with the Permission Attribute.

## Solutions
Solutions folder contains the sollution files for the API.
1. SolutionsAll.sln - contains all the Api's and projects connected with them
1. SolutionAdminWebApi - contains Admin Api for configuring user rights.
1. SolutionAuthorizationWebApi - contains Authorization Web Api for user authenication.
1. SolutionWebApiRouter - a proxu API with client request
