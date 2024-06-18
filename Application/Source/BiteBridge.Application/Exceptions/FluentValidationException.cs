using FluentValidation.Results;

namespace BiteBridge.Application.Exceptions;

public class FluentValidationException : Exception
{
	public IDictionary<string, string[]> Failures { get; }
	public string Type { get; set; }

	public FluentValidationException()
		: base("One or more validation failures have ocurred.")
	{
		Failures = new Dictionary<string, string[]>();
	}

	public FluentValidationException(List<ValidationFailure> failures)
		: this()
	{
		var propertyNames = failures
			.Select(x => x.PropertyName)
			.Distinct();

		foreach (var propertyName in propertyNames)
		{
			var propertyFailures = failures
				.Where(e => e.PropertyName.Equals(propertyName))
				.Select(e => e.ErrorMessage)
				.ToArray();

			var removeString = ".";
			var index = propertyName.IndexOf(removeString);
			var name = (index < 0) ? propertyName : propertyName.Substring(index + 1);

			Failures.Add(name, propertyFailures);
		}
	}

	public FluentValidationException(string propertyName, string error)
		: this()
	{
		Failures.Add(propertyName, [error]);
	}
}