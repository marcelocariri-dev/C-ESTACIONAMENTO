using ESTACIONAMENTO;


internal class Program
{
    private static void Main(string[] args)


    {
        Veiculo v = new Veiculo();
        EMPRESA E = new EMPRESA();
v.menu();
        string? letra = Console.ReadLine();



        switch (letra)
        {  
         case "0":
        E.CADASTRAREmpresa();
                break;
            case "1":
                v.Cadastrarveiculo();
                
                break;

            case "2":
                v.Listarveiculos();
                
                break;
            case "3":
                v.DeleteVeiculos();
                v.menu();
                break;
            case "4":
                E.UpEmpresa();
            
                break;
            case "5":
                E.VerEmpresa();
                break;
            default: Console.WriteLine("opção inválida");
                break;
        }
        
       
    }
}