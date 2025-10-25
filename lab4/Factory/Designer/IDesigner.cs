namespace Factory.Designer;
public interface IDesigner
{
    PictureDraft CreateDraft( StreamReader stream );
}
