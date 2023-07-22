namespace Contacts.Repository.Exceptions;

[Serializable]
public class ContactCanNotNullException : ApplicationException
{
    public override string Message => "El contacto no puede estar vacio.";
}