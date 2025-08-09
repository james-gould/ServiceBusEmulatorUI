# ServiceBusEmulator.Avaloania

This directory serves as a backup of a previous attempt for a UI, a cross-platform supported desktop application that managed the Azure Service Bus Emulator directly within docker.

The functionality is mostly redundant for the new, web-based project - however the knowledge around database interactions is invaluable and very dificult to extract from the SQL-Edge database.

# Structure

[This text file](./edge%20database%20tables.txt) represents the SQL Tables required by the Emulator to structure normalised data, which is then used to inform the queue on pending and previous messages, dead lettering and everything else.

[DockerService](./SBEManagementSuite.Shared/Services/DockerService.cs) was used to directly interface with the database, executed SQL statements with `docker exec` on the CLI (programmatically). This was overkill and the result of a rabbit-hole.