using System.Reflection;
using System.Text;

namespace Flowsy.Auditable.Test.EventSourcing.Domain.Events;

public abstract class DomainEvent
{
    protected DomainEvent(AuditableOperation operation)
    {
        Operation = operation;
    }

    public AuditableOperation Operation { get; }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        var eventType = GetType();
        var eventTypeName = eventType.Name;
        var eventTypeNameLength = eventTypeName.Length;
        var eventTypeNameSeparator = new string('=', eventTypeNameLength);
        
        stringBuilder.AppendLine(eventTypeNameSeparator);
        stringBuilder.AppendLine(eventTypeName);
        stringBuilder.AppendLine(eventTypeNameSeparator);
        
        var properties = eventType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties.Where(p => p.Name != nameof(Operation)))
        {
            var value = property.GetValue(this);
            stringBuilder.AppendLine($"{property.Name}: {value}");
        }
        stringBuilder.Append(Operation);
        
        return stringBuilder.ToString();
    }
}