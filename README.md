# Sigma test task
      How to run

You need to have .NET 6 and SQL server installed, then apply migration in VS's Package Manager Console entering "update-database".

      Some comments
* Could move validation for required fields from attributes to special validation class, and test validations in unit tests as well. And probably validate phone number with regex.
* Should change single TimeInterval field to two CallTimeFrom and CallTimeTo(not necessarily name calltime) datetime  fields.
* Don't think that caching is needed for now.
* Time spent - 6 hours

 
