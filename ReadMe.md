## Playing with Fargate a bit.

The intention is to have a simple API for spiders - get families, get spiders in families, get info about spiders.
Families and spiders have id's.  So far, only implemented get family by name, which isn't complete and the wrong way
to go about things.

This example is created to play with containers - Docker - and possibly Fargate.  So far, the only AWS thing is the
use of Parameter Store to store the connection string.

It uses Entity Framework Core 6 (or whatever it's called these days) to connect to a MySql database.
