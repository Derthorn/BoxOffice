# Welcome to BoxOffice!

BoxOffice is a simple movie API that lets a user look up, add and rate movies... or that is at least what it should do if it was working.

The project got started, a controller was created, but not all of its methods are fully implemented or optimized. The following is a list of the methods that should exist and what they should accomplice.

    * Get - Gets all movies from our repository.
    * Get(Guid id) - Gets a specific movie using its Id, works well but can be slow.
    * Search(string query) - Searches for a movie with a specific title. Works, but not well.
    * SearchByGenre(string[] query) - Searches for movies with matching genres. Does not work as intended.
    * Put(Movie movie) - Should insert a movie into the database once it has been implemented.
    * Rate(Guid id, int rating) - Adds a rating to a specified movie between 0 and 10. Not currently implemented.

Our external movie repository is not working very well, it is slow and only implements two methods. 

    * Get - which returns all movies in the repo.
    * Put - which either updates an existing movie or inserts a new one.

You will need to look to optimize your code so that the slow external repository does not hinder the methods in the movie API.

There also seems like something is wrong with the projects Swagger setup and it could use some love.

On top of this, the movie database is not persistant and resets on app start - Making it persistant is not part of this test, but it is worth noting.

To verify the application, a series of tests have been written in a separate project. They are currently adapted for the current project structure. Please take note that if you do refactor the structure of the project, you may need to update the tests to reflect your changes.

The goal of this test is to implement, refactor and improve all of the Controllers methods. The whole solution could benefit from a bit of cleaning and maybe better Controller-Repository-Service management.



Good luck!