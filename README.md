# Flowsy Auditable

Fundamental components for managing audit trails in applications.

## IAuditable Interface

Represents an auditable entity in your system, which includes the following properties:

| Property     | Type               | Description                                                                                                                       |
|--------------|--------------------|-----------------------------------------------------------------------------------------------------------------------------------|
| Creation     | AuditableOperation | The operation that created the entity.                                                                                            |
| LastMutation | AuditableOperation | The last operation mutating the entity.                                                                                           |
| Lifetime     | AuditableLifetime  | Start, end and duration of the entity's lifetime. For soft deletes, this should represent the time between creation and deletion. |


## AuditableOperation Class

Represents an operation that can be audited, which includes the following properties:

| Property | Type                      | Description                   |
|----------|---------------------------|-------------------------------|
| Type     | AuditableOperationType    | The type of operation.        |
| Instant  | DateTimeOffset            | The instant of the operation. |
| Context  | AuditableOperationContext | The context of the operation. |


## AuditableOperationType Enum

Represents the type of operation that can be audited, which includes the following values:

| Value           | Description                                                                                                                              |
|-----------------|------------------------------------------------------------------------------------------------------------------------------------------|
| Void            | Represents a null or empty operation.                                                                                                    |
| Initialization  | The entity was automatically initialized by the system.                                                                                  |
| Creation        | The entity was created by the user.                                                                                                      |
| Mutation        | The entity was modified by the user.                                                                                                     |
| Synchronization | The entity was synchronized from another entity or some kind of external source.                                                         |
| SoftDeletion    | The entity was soft-deleted by the user. Soft-deleted entities are not actually removed from the system, but marked as deleted.          |
| HardDeletion    | The entity was hard-deleted by the user. Hard-deleted entities are actually removed from the system and cannot be restored.              |
| Restoration     | The previously soft-deleted entity was restored, so it is no longer marked as deleted, has a new lifetime and is fully functional again. |


## AuditableOperationContext Class

Represents the context of an auditable operation, which includes the following properties:

| Property         | Type                         | Description                                                            |
|------------------|------------------------------|------------------------------------------------------------------------|
| UserId           | string                       | The unique identifier of the user who performed the operation.         |
| UserNickname     | string                       | The nickname of the user who performed the operation.                  |
| UserAccountId    | string                       | The unique identifier of the user account who performed the operation. |
| UserAccountEmail | string                       | The email of the user account who performed the operation.             |
| Details          | IDictionary<string, object?> | Additional details about the operation.                                |

For systems where a user can only have one account, `UserId` and `UserAccountId` shall be the same.


## IAuditableOperationContextProvider Interface

Provides the context for an auditable operation.
Implementations of this interface should resolve the operation context according to the current environment.
For example, a web application could resolve the operation context from the current HTTP request.
