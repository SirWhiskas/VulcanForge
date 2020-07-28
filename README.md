# Vulcan Forge API

This web api will allow POST/GET requests for data in a RESTful fashion and provide a custom backend solution for a dedicated frontend (will provide link in the future).

## Design
VulcanForge contains these models:

 - User
 - Campaign Setting
 - World
 - Resource
 - Resource Type
 - Asset

#### User
As you might expect, this describes the users who will authenticate themselves through the frontend and create worlds.

*User Authentication*
Using the example found here: [Jason Watmore - .net core v3.1 authentication](https://jasonwatmore.com/post/2019/10/14/aspnet-core-3-simple-api-for-authentication-registration-and-user-management)

VulcanForge uses the Bearer Authentication format and will return JWTs to the client for authentication. For more details on how this works, refer to the **Tutorials** section at the bottom of the readme.

#### World & Campaign Setting
Authenticated users can create their own world with only a *name* and a *description*. They can create as many worlds as they want but each world can have any number of **Campaign Settings**. Campaign settings will act as a linear versioning system for a world. Creating a world automatically creates an initial campaign setting. When the user wishes to create another campaign setting for a world, all of the data connected to that world under the previous campaign setting will set to a READ-ONLY state. That way, each world will progress linerally and there won't be any "forked" versions.

#### Resource & Resource Types
After creating a world, users can attach any number of resources from a **fixed** list of resource types. Currently, this is the accepted list of resource types:

 1. Geography
 2. Items
 3. Monsters
 4. NPCs
 5. Physics
 6. Races
 7. Religion

Adding a resource to a world is completely **OPTIONAL**. A world could contain no resources or a maxiumum of 7 resources.

#### Assets
Once a user adds a resource to the world, they can add any number of assets to the resource. For example, a user could add the *Geography* resource to their world and then attach assets related to geography/locations such as cities, buildings, maps, etc. At this point, the user has free reign on the assets. When attaching an asset, the user can upload an image to depict the asset, enter a name, and a description. There will probably be more fields in the future, but, for now, we are only providing a rich-text box for the users on the frontend.


*Notes:*
*I plan to attach visuals such as flow charts and diagrams to better illustrate VulcanForge in the future. We're still in the early development stage, so nothing is too  set-in-stone. The goal is to create a working prototype under this design and have it successfully interface with a frontend system.*


## Tutorials

#### User Authentication
To test authentication, run a migration as so:
```
dotnet ef migrations add InitialCreate --context SqliteDataContext
```
From there, use Postman for the following endpoints:

###### Registration
Endpoint: http://localhost:5000/users/register
Body:
```
{
    "firstName": "John",
    "lastName": "Doe",
    "username": "jdoe",
    "password": "my-super-secret-password"
}
```

###### Authenticate
Endpoint: http://localhost:5000/users/authenticate
Body: 
```
{
    "username": "jdoe",
    "password": "my-super-secret-password"
}
```
Return:
```
{
    "id": 1,
    "username": "jdoe",
    "firstName": "John",
    "lastName": "Doe",
    "token": "TOKEN"
}
```

###### Get User By Token
*Copy the token value from Authenticate endpoing*
Endpoint: http://localhost:5000/users
Body: None
Authorization: Type -> Bearer Token; Token -> Copied value form Authenticate endpoint
Return:
```
{
    "id": 1,
    "username": "jdoe",
    "firstName": "John",
    "lastName": "Doe"
}
```

###### Update User By Token
*Copy the token value from Authenticate endpoing*
Endpoint: http://localhost:5000/users/1
Body: 
```
{
    "firstName": "Foo",
    "lastName": "Bar"
}
```
Authorization: Type -> Bearer Token; Token -> Copied value form Authenticate endpoint

*- Then run Get User By Token endpoint to see the updated first name and last name*