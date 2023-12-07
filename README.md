# VibrantCast Platform

The VibrantCast Platform is a Blazor WebApp that allows artists, gallery, and other organzations to not only create and manage and artwork portfolio, but also interact with the artist community.

Users have the ability to upload their own individual artwork portfolio, add details about their artwork, message other artists, and upgrade their membership. 

Organizations such as galleries, artistt collectives, and schools can showcase the artwork of their members.

Future improvements:
* Ability to create collections and add artwork to it
* Add activity tracking (clicks, opens, experiences, inquiries)
* Allow users to create and associate experience(s) to their artwork
* Add a collaborators table to associate multiple artists with artwork
* Add activity dashboard for artists and organizations



## API Documentation

* [User](#user-controller)
* [Artwork](#artwork-controller)
* [Inquiry](#inquiry-controller)
* [MediumTag](#mediumTag-controller)
* [MembershipType](#membershipType-controller)
* [Organization](#organization-controller)
* [UserAccountInfo](#user-account-information-controller)


## User Controller

Users are created using built-in ASP.NET functionality.

The AspNetUsers table is mapped either directly or indirectly to the following tables:
* AspNetRoleClaims
* AspNetRoles
* AspNetUserClaims
* AspNetUserLogins
* AspNetUserRoles
* AspNetUserTokens


## Artwork Controller

**Route:** `/api/artwork`

**Authentication:** All routes except the public ones require valid user authentication.

**Data Model:**

* `ArtworkDetail`: Represents detailed information about a piece of artwork.
* `ArtworkCreate`: Model for creating a new artwork.
* `ArtworkUpdate`: Model for updating an existing artwork.
* `MediumTagListName`: Represents a list of medium tag names associated with an artwork.

**Operations:**

### Create

1. **`POST /create`**: Upload a new artwork.
    * Parameters:
        * `ArtworkCreate`: Model containing artwork details.
    * Responses:
        * `200 OK`: Artwork uploaded successfully.
        * `400 Bad Request`: Invalid request body.
        * `401 Unauthorized`: User not authenticated.
        * `422 Unprocessable Entity`: Artwork creation failed.
2. **`POST /create-mediumtag`**: Add a medium tag to an existing artwork.
    * Parameters:
        * `ArtworkMediumTagMapping`: Model containing artwork ID and medium tag ID.
    * Responses:
        * `200 OK`: Medium tag added successfully.
        * `400 Bad Request`: Invalid request body.
        * `401 Unauthorized`: User not authenticated.
        * `422 Unprocessable Entity`: Medium tag addition failed.

### Read

1. **`GET`**: Get all artwork owned by the authenticated user.
    * Responses:
        * `200 OK`: List of `ArtworkDetail` objects.
        * `401 Unauthorized`: User not authenticated.
2. **`GET {creatorId}/public`**: Get all public artwork created by a specific artist.
    * Parameters:
        * `creatorId`: ID of the artist.
    * Responses:
        * `200 OK`: List of `ArtworkDetail` objects.
3. **`GET public`**: Get all public artwork.
    * Responses:
        * `200 OK`: List of `ArtworkDetail` objects.
4. **`GET {id}`**: Get details of a specific artwork.
    * Parameters:
        * `id`: ID of the artwork.
    * Responses:
        * `200 OK`: Object of type `ArtworkDetail`.
        * `401 Unauthorized`: User not authenticated.
        * `404 Not Found`: Artwork not found.
5. **`GET public/{id}`**: Get details of a specific artwork publicly.
    * Parameters:
        * `id`: ID of the artwork.
    * Responses:
        * `200 OK`: Object of type `ArtworkDetail`.
        * `404 Not Found`: Artwork not found.
6. **`GET mediumtag/{artworkId}`**: Get all medium tags associated with a specific artwork.
    * Parameters:
        * `artworkId`: ID of the artwork.
    * Responses:
        * `200 OK`: List of `MediumTagListName` objects.
7. **`GET artwork-org-mapped/{orgId}`**: Get all artwork mapped to a specific organization.
    * Parameters:
        * `orgId`: ID of the organization.
    * Responses:
        * `200 OK`: List of `ArtworkDetail` objects.

### Update

1. **`PUT /edit/{id}`**: Update details of a specific artwork.
    * Parameters:
        * `id`: ID of the artwork.
        * `ArtworkUpdate`: Model containing updated artwork details.
    * Responses:
        * `200 OK`: Artwork updated successfully.
        * `400 Bad Request`: Invalid request body or invalid ID mismatch.
        * `401 Unauthorized`: User not authenticated.
        * `422 Unprocessable Entity`: Artwork update failed.

### Delete

1. **`DELETE {id}`**: Delete a specific artwork.
    * Parameters:
        * `id`: ID of the artwork.
    * Responses:
        * `200 OK`: Artwork deleted successfully.
        * `401 Unauthorized`: User not authenticated.
        * `404 Not Found`: Artwork not found.
        * `400 Bad Request`: Artwork deletion failed.

**Additional Notes:**

* The `SetUserIdInService` method is used internally to associate



## Inquiry Controller

**Route:** `/api/inquiry`

**Authentication:** All routes require valid user authentication.

**Data Model:**

* `InquiryCreate`: Model for creating a new inquiry.
* `InquiryDetail`: Represents detailed information about a specific inquiry.

**Operations:**

### Create

1. **`POST /create`**: Create a new inquiry.
    * Parameters:
        * `InquiryCreate`: Model containing inquiry details.
    * Responses:
        * `200 OK`: Inquiry created successfully.
        * `401 Unauthorized`: User not authenticated.
        * `422 Unprocessable Entity`: Inquiry creation failed.

### Read

1. **`GET /sent`**: Get all inquiries sent by the authenticated user.
    * Responses:
        * `200 OK`: List of `InquiryDetail` objects.
        * `401 Unauthorized`: User not authenticated.
2. **`GET`**: Get all inquiries received by the authenticated user.
    * Responses:
        * `200 OK`: List of `InquiryDetail` objects.
        * `401 Unauthorized`: User not authenticated.
3. **`GET {id}`**: Get details of a specific inquiry.
    * Parameters:
        * `id`: ID of the inquiry.
    * Responses:
        * `200 OK`: Object of type `InquiryDetail`.
        * `401 Unauthorized`: User not authenticated.
        * `404 Not Found`: Inquiry not found.

**Additional Notes:**

* The `SetUserIdInService` method is used internally to associate API calls with the currently logged-in user.
* All responses are in JSON format.
* This documentation does not include implementation details of the service or data models.


## MediumTag Controller

**Route:** `/api/mediumtag`

**Authentication:** None required.

**Data Model:**

* `MediumTagCreate`: Model for creating a new medium tag.
* `MediumTagDetail`: Represents detailed information about a specific medium tag.
* `MediumTagListName`: Represents just the name of a medium tag.
* `MediumTagEdit`: Model for editing an existing medium tag.

**Operations:**

### Create

1. **`POST /create`**: Create a new medium tag.
    * Parameters:
        * `MediumTagCreate`: Model containing medium tag details.
    * Responses:
        * `200 OK`: Medium tag created successfully.
        * `400 Bad Request`: Invalid request body.
        * `422 Unprocessable Entity`: Medium tag creation failed.

### Read

1. **`GET`**: Get all medium tags.
    * Responses:
        * `200 OK`: List of `MediumTagDetail` objects.
2. **`GET names`**: Get a list of just the names of all medium tags.
    * Responses:
        * `200 OK`: List of `MediumTagListName` objects.
3. **`GET edit/{id}`**: Get a specific medium tag for editing.
    * Parameters:
        * `id`: ID of the medium tag.
    * Responses:
        * `200 OK`: Object of type `MediumTagEdit`.
        * `404 Not Found`: Medium tag not found.

### Update

1. **`PUT /edit/{id}`**: Update an existing medium tag.
    * Parameters:
        * `id`: ID of the medium tag.
        * `MediumTagEdit`: Model containing updated medium tag details.
    * Responses:
        * `200 OK`: Medium tag updated successfully.
        * `400 Bad Request`: Invalid request body or ID mismatch.
        * `422 Unprocessable Entity`: Medium tag update failed.

### Delete

1. **`DELETE {id}`**: Delete a specific medium tag.
    * Parameters:
        * `id`: ID of the medium tag.
    * Responses:
        * `200 OK`: Medium tag deleted successfully.
        * `404 Not Found`: Medium tag not found.
        * `400 Bad Request`: Medium tag deletion failed.

**Additional Notes:**

* All responses are in JSON format.
* This documentation does not include implementation details of the service or data models.

## MembershipType Controller

**Route:** `/api/membershiptype`

**Authentication:** Requires authorization.

**Data Model:**

* `MembershipTypeCreate`: Model for creating a new membership type.
* `MembershipTypeDetail`: Represents detailed information about a specific membership type.
* `MembershipTypeEdit`: Model for editing an existing membership type.

**Operations:**

### Create

1. **`POST /create`**: Create a new membership type.
    * Parameters:
        * `MembershipTypeCreate`: Model containing membership type details.
    * Responses:
        * `200 OK`: Membership type created successfully.
        * `400 Bad Request`: Invalid request body.
        * `401 Unauthorized`: User not authorized.
        * `422 Unprocessable Entity`: Membership type creation failed.

### Read

1. **`GET`**: Get all membership types available to the authenticated user.
    * Responses:
        * `200 OK`: List of `MembershipTypeDetail` objects.
        * `401 Unauthorized`: User not authorized.
2. **`GET {id}`**: Get details of a specific membership type.
    * Parameters:
        * `id`: ID of the membership type.
    * Responses:
        * `200 OK`: Object of type `MembershipTypeDetail`.
        * `401 Unauthorized`: User not authorized.
        * `404 Not Found`: Membership type not found.

### Update

1. **`PUT /edit/{id}`**: Update an existing membership type.
    * Parameters:
        * `id`: ID of the membership type.
        * `MembershipTypeEdit`: Model containing updated membership type details.
    * Responses:
        * `200 OK`: Membership type updated successfully.
        * `400 Bad Request`: Invalid request body, ID mismatch, or invalid model state.
        * `401 Unauthorized`: User not authorized.
        * `422 Unprocessable Entity`: Membership type update failed.

### Delete

1. **`DELETE /delete/{id}`**: Delete a specific membership type.
    * Parameters:
        * `id`: ID of the membership type.
    * Responses:
        * `200 OK`: Membership type deleted successfully.
        * `401 Unauthorized`: User not authorized.
        * `422 Unprocessable Entity`: Membership type deletion failed.

**Additional Notes:**

* All responses are in JSON format.
* This documentation does not include implementation details of the service or data models.
* This API provides a comprehensive set of tools for managing membership types.

## Organization Controller

**Route:** `/api/organization`

**Authentication:** Most routes require authorization, except for `GET /check/{id}`, `GET /dashboard/{orgName}`, and `GET /all`.

**Data Model:**

* `OrganizationCreate`: Model for creating a new organization.
* `OrganizationInfoCreate`: Model for creating an organization's profile.
* `OrgUserMappingCreate`: Model for mapping a user to an organization.
* `OrgInfoDetail`: Represents detailed information about an organization.
* `OrgUserMappingDetail`: Represents details about a user's membership in an organization.
* `OrganizationInfoEdit`: Model for editing an organization's profile.
* `OrgMembershipUpgrade`: Model for upgrading an organization's membership.

**Operations:**

### Create

1. **`POST /signup`**: Create a new organization.
    * Parameters:
        * `OrganizationCreate`: Model containing organization details.
    * Responses:
        * `200 OK`: Organization created successfully.
        * `400 Bad Request`: Invalid request body.
        * `401 Unauthorized`: User not authorized.
        * `422 Unprocessable Entity`: Organization creation failed.
2. **`POST /profile`**: Create an organization's profile.
    * Parameters:
        * `OrganizationInfoCreate`: Model containing organization's profile information.
    * Responses:
        * `200 OK`: Organization profile created successfully.
        * `400 Bad Request`: Invalid request body.
        * `401 Unauthorized`: User not authorized.
        * `422 Unprocessable Entity`: Organization profile creation failed.
3. **`POST /add-members`**: Add a user as a member to an organization.
    * Parameters:
        * `OrgUserMappingCreate`: Model containing user and organization ID.
    * Responses:
        * `200 OK`: User added to organization successfully.
        * `400 Bad Request`: Invalid request body or missing user ID.
        * `401 Unauthorized`: User not authorized.
        * `422 Unprocessable Entity`: User could not be added to organization.

### Read

1. **`GET /check/{id}`**: Check if an organization exists with a specific ID.
    * Parameters:
        * `id`: ID of the organization.
    * Responses:
        * `200 OK`: True if organization exists, false otherwise.
        * `401 Unauthorized`: User not authorized.
        * `404 Not Found`: Organization not found.
2. **`GET /checkmapping/{userId}`**: Check if a user is mapped to any organization.
    * Parameters:
        * `userId`: User's ID.
    * Responses:
        * `200 OK`: Details about user's organization mapping if exists, null otherwise.
        * `401 Unauthorized`: User not authorized.
        * `404 Not Found`: User's organization mapping not found.
3. **`GET /org-mapped-users/{orgId}`**: Get a list of users mapped to a specific organization.
    * Parameters:
        * `orgId`: ID of the organization.
    * Responses:
        * `200 OK`: List of `OrgUserMappingDetail` objects representing mapped users.
        * `401 Unauthorized`: User not authorized.
        * `404 Not Found`: Organization not found.
4. **`GET /{orgId}`**: Get the profile of a specific organization.
    * Parameters:
        * `orgId`: ID of the organization.
    * Responses:
        * `200 OK`: Object of type `OrgInfoDetail` containing organization's profile information.
        * `404 Not Found`: Organization not found.
5. **`GET /dashboard/{orgName}`**: Get the profile of a specific organization by its name (public endpoint).
    * Parameters:
        * `orgName`: Name of the organization.
    * Responses:
        * `200 OK`: Object of type `OrgInfoDetail` containing organization's profile information.
        * `404 Not Found`: Organization not found.
6. **`GET /all`**: Get all organization profiles.
    * Responses:
        * `200 OK`: List of `OrgInfoDetail` objects containing all organization profiles.
### Update

** need to finish


## User Account Information Controller

**Route:** `/api/profile/accountinfo`

This controller handles user account information related operations.

**Authentication:** Most routes require authorization, except for `GET /public-users`.

**Data Model:**

* `UserAccountInfoCreate`: Model for creating a user account information.
* `UserAccountInfoDetail`: Represents detailed information about a user's account.
* `UserAccountInfoEdit`: Model for editing a user's account information.
* `UserMembershipUpgrade`: Model for upgrading a user's membership.

**Operations:**

### Create

1. **`POST /`**: Create a new user account information.
    * Parameters:
        * `UserAccountInfoCreate`: Model containing user account information.
    * Responses:
        * `200 OK`: User account information created successfully.
        * `400 Bad Request`: Invalid request body.
        * `401 Unauthorized`: User not authorized.
        * `422 Unprocessable Entity`: User account information creation failed.

### Read

1. **`GET /{userId}`**: Get the user account information for a specific user.
    * Parameters:
        * `userId`: ID of the user.
    * Responses:
        * `200 OK`: Object of type `UserAccountInfoDetail` containing user account information.
        * `404 Not Found`: User not found.
2. **`GET /artist/{artistName}`**: Get the user account information for a specific artist by their name.
    * Parameters:
        * `artistName`: Name of the artist.
    * Responses:
        * `200 OK`: Object of type `UserAccountInfoDetail` containing user account information.
        * `404 Not Found`: Artist not found.
3. **`GET /public-user/{userId}`**: Get the public profile of a specific user.
    * Parameters:
        * `userId`: ID of the user.
    * Responses:
        * `200 OK`: Object of type `UserAccountInfoDetail` containing user's public profile information.
        * `404 Not Found`: User not found.
4. **`GET /public-users`**: Get all public user profiles.
    * Responses:
        * `200 OK`: List of `UserAccountInfoDetail` objects containing public user profiles.

### Update

1. **`PUT /`**: Edit a user's account information.
    * Parameters:
        * `UserAccountInfoEdit`: Model containing updated user account information.
    * Responses:
        * `200 OK`: User account information updated successfully.
        * `400 Bad Request`: Invalid request body.
        * `401 Unauthorized`: User not authorized.
        * `422 Unprocessable Entity`: User account information update failed.

2. **`PUT /membership-upgrade`**: Upgrade a user's membership.
    * Parameters:
        * `UserMembershipUpgrade`: Model containing user and desired membership level.
    * Responses:
        * `200 OK`: User's membership upgraded successfully.
        * `400 Bad Request`: Invalid request body or missing user ID.
        * `401 Unauthorized`: User not authorized.
        * `422 Unprocessable Entity`: User's membership upgrade failed.

3. **`GET /membership-status/{userId}`**: Get a user's membership status.
    * Parameters:
        * `userId`: ID of the user.
    * Responses:
        * `200 OK`: Object containing details about user's membership status.
        * `404 Not Found`: User not found.
        * `422 Unprocessable Entity`: User does not have a membership.
