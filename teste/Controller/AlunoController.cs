using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/aluno")]

    public class AlunoController : ControllerBase
    {
        private static List<Aluno> alunos = new List<AlunoController>(); //para atualizar a lista d alunos

        private DataContext _context; //para chamar o context, que é como se fosse uma chave do bd


        public AlunoController(DataContext context)
        {
            _context = context; //o _context é o context
        }


        //Cadastro
        [HttpPost]
        [Route("cadastroaluno")] //cria a url

        public IActionResult cadastroaluno([FromBody]Aluno aluno) //FromBody: Para forçar a API Web a ler um tipo simples do corpo da solicitação, adicione o atributo [FromBody] ao parâmetro:
        {
            _context.Alunos.Add(aluno); //adiciona as informaçoes digitadas em aluno no _context
            _context.SaveChanges(); //salva essas informações
            return Created("",aluno); //cadastra o aluno
        }

        //Listar
        [HttpGet]
        [Route("listaraluno")]

        public IActionResult listaraluno() //IActionResult: é uma requisição que volta alguma coisa...um ok, um erro
        {
            return Ok(_context.Funcionarios.ToList());
        }

        //Buscar
        [HttpGet]
        [Route("buscar/{cpf}")] //coloca oq vc quer buscar

        puclic IactionResult Buscar([FromRoute] string cpf ) //FromRoute: recupera os dados que voce informou//balta.io
    }
}