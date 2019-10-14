# CQRSwithEventSourcingExample
Example CQRS with Event Sourcing + DI container

CQRS with Event Sourcing gives several advantages out of the box:

1) When dividing Read and Write models into different databases - the ability to separately scale them
2) The reliability of these individual services, because they are separate
3) Historical data due to the storage of the history of teams
4) Logging due to historicity (you can generate logs in a separate table)
5) It is possible to do self-generation of entities upon the arrival of commands. Entities may be different.

