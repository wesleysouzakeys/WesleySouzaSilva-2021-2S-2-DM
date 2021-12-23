/*
Declare uma variável chamada `isTruthy`, e atribua a ela uma função que recebe
um único parâmetro como argumento. Essa função deve retornar `true` se o
equivalente booleano para o valor passado no argumento for `true`, ou `false`
para o contrário.
*/

// const param = new Boolean(true);

// var isTruthy = function (parametro) {
//     if (param === true) {
//         return true
//     } return false
// }

// Invoque a função criada acima, passando todos os tipos de valores `falsy`.
// console.log(isTruthy(param))

/*
Invoque a função criada acima passando como parâmetro 10 valores `truthy`.
*/

// for (let index = 0; index < 10; index++) {
//     console.log(isTruthy(param))
// }

/*
Declare uma variável chamada `carro`, atribuindo à ela um objeto com as
seguintes propriedades (os valores devem ser do tipo mostrado abaixo):
- `marca` - String
- `modelo` - String
- `placa` - String
- `ano` - Number
- `cor` - String
- `quantasPortas` - Number
- `assentos` - Number - cinco por padrão
- `quantidadePessoas` - Number - zero por padrão
*/

var carro = 
{
    marca: 'Honda',
    modelo: 'HR-V',
    placa: '',
    ano: new Number(),
    cor: '',
    quantasPortas: new Number(),
    assentos: new Number(5),
    quantidadePessoas: Number(0)
}

/*
Crie um método chamado `mudarCor` que mude a cor do carro conforme a cor
passado por parâmetro.
*/

carro.mudarCor = function(novaCor)
{
    carro.cor = novaCor
} 

/*
Crie um método chamado `obterCor`, que retorne a cor do carro.
*/

carro.obterCor = function()
{
    return carro.cor
}

/*
Crie um método chamado `obterModelo` que retorne o modelo do carro.
*/

carro.obterModelo = function()
{
    return carro.modelo
}

/*
Crie um método chamado `obterMarca` que retorne a marca do carro.
*/

carro.obterMarca = function()
{
    return carro.marca
}

/*
Crie um método chamado `obterMarcaModelo`, que retorne:
"Esse carro é um [MARCA] [MODELO]"
Para retornar os valores de marca e modelo, utilize os métodos criados.
*/

carro.obterMarcaModelo = function()
{
    return `Esse carro é um ${carro.marca} ${carro.modelo}`
}

/*
Crie um método que irá adicionar pessoas no carro. Esse método terá as
seguintes características:
- Ele deverá receber por parâmetro o número de pessoas entrarão no carro. Esse
número não precisa encher o carro, você poderá acrescentar as pessoas aos
poucos.
- O método deve retornar a frase: "Já temos [X] pessoas no carro!"
- Se o carro já estiver cheio, com todos os assentos já preenchidos, o método
deve retornar a frase: "O carro já está lotado!"
- Se ainda houverem lugares no carro, mas a quantidade de pessoas passadas por
parâmetro for ultrapassar o limite de assentos do carro, então você deve
mostrar quantos assentos ainda podem ser ocupados, com a frase:
"Só cabem mais [QUANTIDADE_DE_PESSOAS_QUE_CABEM] pessoas!"
- Se couber somente mais uma pessoa, mostrar a palavra "pessoa" no retorno
citado acima, no lugar de "pessoas".
*/

carro.entrar = function(quantidadePessoas)
{
    if (carro.quantidadePessoas === 5) {
        return console.log(`O carro já está lotado`)
    }else{
        if ((quantidadePessoas + carro.quantidadePessoas) <= 5) {
            carro.quantidadePessoas = carro.quantidadePessoas + quantidadePessoas
            return console.log(`Já temos ${carro.quantidadePessoas} pessoas no carro!`)
        }
        if (5 - carro.quantidadePessoas > 1) {
            return console.log(`Só cabem mais ${5 - carro.quantidadePessoas} pessoas!`)
        }
        return console.log(`Só cabem mais ${5 - carro.quantidadePessoas} pessoa!`)
    }
}

/*
Agora vamos verificar algumas informações do carro. Para as respostas abaixo,
utilize sempre o formato de invocação do método (ou chamada da propriedade),
adicionando comentários _inline_ ao lado com o valor retornado, se o método
retornar algum valor.

Qual a cor atual do carro?
*/

// console.log(carro.obterCor()) //nenhum retorno

// Mude a cor do carro para vermelho.

// carro.mudarCor('vermelho') //cor alterada

// E agora, qual a cor do carro?

// console.log(carro.obterCor()) //vermelho

// Mude a cor do carro para verde musgo.

// carro.mudarCor('verde musgo') //cor alterada

// E agora, qual a cor do carro?

// console.log(carro.obterCor()) //verde musgo

// Qual a marca e modelo do carro?

// console.log(carro.obterMarcaModelo())

// Adicione 2 pessoas no carro.

carro.entrar(2)

// Adicione mais 4 pessoas no carro.

carro.entrar(4)

// Faça o carro encher.

for (let index = 0; index < carro.assentos; index++) {
    carro.entrar(1)
}

// Tire 4 pessoas do carro.

carro.quantidadePessoas - 4

// Adicione 10 pessoas no carro.

carro.entrar(10)

// Quantas pessoas temos no carro?

console.log(carro.quantidadePessoas + ' pessoas a bordo')