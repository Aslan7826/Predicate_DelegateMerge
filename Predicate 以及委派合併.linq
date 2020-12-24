<Query Kind="Program">
  <Namespace>System.Collections.Concurrent</Namespace>
</Query>

void Main()
{
	var thisType = typeof(string);
	int? order = 5;
	HashSet<EventHandlerType> all = new HashSet<EventHandlerType>();
	all.Add(new EventHandlerType(){EventHandlerTypes= typeof(int),Order =5});
	all.Add(new EventHandlerType(){EventHandlerTypes= thisType,Order =5});
	all.Add(new EventHandlerType(){EventHandlerTypes= thisType,Order =4});
	all.Dump();
	
	Predicate<EventHandlerType> bool1 = o => o.EventHandlerTypes == thisType;
    var select = bool1;
    if(order.HasValue) 
    {
		Predicate<EventHandlerType> bool2 = o => o.Order == order.Value;
		select = o => bool1(o) && bool2(o);
    }
	all.RemoveWhere(select);
	all.Dump();
}

// You can define other methods, fields, classes and namespaces here
    public class EventHandlerType
    {
        public int Order { get; set; }
        public Type EventHandlerTypes { get; set; }
    }