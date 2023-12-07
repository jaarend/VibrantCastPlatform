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
