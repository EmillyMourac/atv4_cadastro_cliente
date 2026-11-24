/* 
Importa o namespace onde está localizada
a classe ConexaoBanco.
*/
using cadastro_cliente.Data;

/*
Importa os recursos do ASP.NET Core MVC.
Esse namespace fornece classes e atributos como:
ControllerBase, ApiController, Route, HttpGet e IActionResult.
*/
using Microsoft.AspNetCore.Mvc;

/*
Define que esta classe pertence ao namespace LojaApi.Controllers.
O namespace ajuda a organizar os Controllers da aplicação.
*/
namespace cadastro_cliente.Controllers;

/* 
Informa ao ASP.NET Core que esta classe
será utilizada como Controller de uma API.
Esse atributo também ativa comportamentos automáticos,
como a validação dos dados recebidos pela API.
*/
[ApiController]

/* 
Define a rota principal deste Controller.
Todas as rotas declaradas nesta classe começarão com:
api/conexao
*/
[Route("api/conexao")]

/*
Declara a classe pública ConexaoController.
A classe herda de ControllerBase para receber recursos
necessários à criação de Controllers de uma API,
como os métodos Ok(), NotFound() e BadRequest().
*/
public class ConexaoController : ControllerBase
{
    /* Declara um atributo privado que armazenará
    // uma referência para a classe ConexaoBanco.
    //
    // readonly determina que o atributo somente poderá
    // receber um valor durante sua declaração
    // ou dentro do construtor.
    */
    private readonly ConexaoBanco _conexaoBanco;

    /*
    // Construtor da classe ConexaoController.
    //
    // O ASP.NET Core fornecerá automaticamente um objeto
    // ConexaoBanco por meio da injeção de dependência.
    */
    public ConexaoController(ConexaoBanco conexaoBanco)
    {
        // Armazena no atributo privado o objeto recebido
        // pelo parâmetro do construtor.
        _conexaoBanco = conexaoBanco;
    }

    /*
    // Define que o metodo abaixo respondera
    // a requisicoes HTTP do tipo GET.
    //
    // O trecho "testar" e acrescentado a rota principal.
    //
    // A rota completa sera:
    // GET /api/conexao/testar
    */
    [HttpGet("testar")]

    /*
    // Declara o metodo publico e assincrono Testar.
    //
    // Task indica que o metodo executara
    // uma operacao assoncrona.
    //
    // IActionResult permite que o metodo devolva
    // uma resposta HTTP.
    */
    public async Task<IActionResult> Testar()
    {
        /*
        // Chama o metodo TestarAsync() da classe ConexaoBanco.
        //
        // O await aguarda o termino do teste de conexao
        // sem bloquear a aplicacao.
        //
        // O resultado true ou false sera armazenado
        // na variavel conectou.
        */
        bool conectou =
            await _conexaoBanco.TestarAsync();

        /* O metodo Ok() cria uma resposta HTTP
        com o codigo 200 - OK.        
        O conteudo colocado dentro de Ok()
        sera convertido automaticamente para JSON.*/
        return Ok(

            /* Cria um objeto anonimo.
            Um objeto anonimo e um objeto criado
            sem declarar uma classe especifica para ele.*/
            new
            {
                // Cria a propriedade mensagem
                // que sera enviada na resposta JSON.
                mensagem =

                    // O operador ternario verifica
                    // o valor da variavel conectou.
                    conectou

                        // Se conectou for true,
                        // esta mensagem sera utilizada.
                        ? "Conexao realizada com sucesso."

                        // Se conectou for false,
                        // esta mensagem sera utilizada.
                        : "Nao foi possivel conectar."
            }
        );
    }
}