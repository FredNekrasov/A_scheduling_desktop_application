namespace Model.captcha;

public class GenerateCaptcha
{
    private const string symbols = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z,1,2,3,4,5,6,7,8,9,0";
    private readonly string[] font =
    [
        "ALGERIAN",
        "Brush Script MT",
        "Chiller",
        "Colonna MT",
        "Ravie",
        "Parchment",
        "Old English Text MT",
        "Mistral",
        "Magneto",
        "Harrington",
        "Informal Roman",
        "Kunstler Script",
        "Harlow Solid Italic",
        "MV Boli",
        "Gabriola",
        "Freestyle Script"
    ];
    private string result = string.Empty;
    private readonly Random random = new();
    public string GenerateCaptchaCode()
    {
        result = string.Empty;
        string[] code = symbols.Split(',');
        for (int i = 0; i < 8; i++)
        {
            result += $"{code[random.Next(0, code.Length)]}";
        }
        result += $",{font[random.Next(0, font.Length)]}";
        return result;
    }
}
