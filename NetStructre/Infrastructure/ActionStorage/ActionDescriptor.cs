namespace NetStructre;

public sealed record ActionDescriptor(
    bool AuditLogRequired,
    bool TransactionRequired,
    Type? RequestType,
    Type? ResponseType);


// public class Action
// {
//     public bool AuditLogRequired { get; set; }
//     public bool TransactionRequired { get; set; }
//     public Type? RequestType { get; set; }
//     public Type? ResponseType { get; set; }
//
//     public Action(bool auditLogRequired, bool transactionRequired, Type? requestType, Type? responseType)
//     {
//         AuditLogRequired = auditLogRequired;
//         TransactionRequired = transactionRequired;
//         RequestType = requestType;
//         ResponseType = responseType;
//     }
// }