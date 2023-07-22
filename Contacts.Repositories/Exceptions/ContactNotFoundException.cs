namespace Contacts.Repository.Exceptions;

[Serializable]
public class ContactNotFoundException : ApplicationException
{
    public override string Message => "El contacto no exite para realizar la edicion.";
}