# MTG Deck Builder Project - Warre Welvaert

## What is this?
This repository contains a ASP .NET project that allows users to search for and filter Magic The Gathering cards. The user can then build different decks with these cards.

The application contains:
- Web API that gets cards and decks.
- Minimal API to post update and delete card decks.
- GraphQL to retrieve cards and artists.
- Blazor web app responsible for the front end. 

A video that demonstrates the application can be found [here](https://www.youtube.com/watch?v=s1d6abSZd0k)

In order to function correctly a local database with magic the gathering cards is required, and
the Minimal API, Web API and web application should be running at the same time.

## Additional Notes
- The Decks are stored in a JSON file by the Minimal API.
- The GraphQL playground can be found on [https://localhost:7116/ui/playground](https://localhost:7116/ui/playground)
- Although the Minimal API has two GET endpoints for the Decks, they are never called in the Blazor app where the Web API is always called for getting the decks. The Minimal API only has these endpoints to make debugging easier.