namespace Store.Contractors
{
    public class Form
    {
        public string UniqueCode { get; } = "";
        public int OrderId { get; }
        public int Step { get; }
        public bool IsFinal { get; }
        public IReadOnlyList<Field> Fields { get; }

        public Form(
            string uniqueCode,
            int orderId,
            int step,
            bool isFinal,
            IReadOnlyList<Field> fields)
        {
            if (string.IsNullOrWhiteSpace(uniqueCode))
                throw new ArgumentException(nameof(uniqueCode));

            if (step < 1)
                throw new ArgumentException(nameof(step));

            if (fields == null)
                throw new ArgumentNullException(nameof(fields));

            UniqueCode = uniqueCode;
            OrderId = orderId;
            Step = step;
            IsFinal = isFinal;
            Fields = fields;
        }
    }
}
