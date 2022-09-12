# DesafioClimaTempo
## Projeto desenvolvido para processo de seleção da AUVO SISTEMAS

![image](https://user-images.githubusercontent.com/5097184/189503773-befc0cce-fcde-4655-878e-c0ea64e1da13.png)

<p align="center"></p>
<g-emoji class="g-emoji" alias="rocket" fallback-src="https://github.githubassets.com/images/icons/emoji/unicode/1f680.png">🚀</g-emoji><b>Tecnologias</b><br>
<ul dir="auto">
<li>.Net Framework 4.6.1</li>
<li>C#</li>
<li>Framework <b>Microsoft.AspNet.Mvc 5.2.7</b></li>
<li>Entity Framework</li>
<li>SQL Server</li>
</ul>
<g-emoji class="g-emoji" alias="computer" fallback-src="https://github.githubassets.com/images/icons/emoji/unicode/1f4bb.png">💻</g-emoji> <b>Projeto</b><br>
<p>
O projeto foi seguimentado em em:
<ul dir="auto">
<li>
<p>Class Library Domain: <b>DesafioClimaTempo.Domain</b> - Contendo os model e o DbContext  </p>
</li>

<li>
<p>Application console: <b>DesafioClimaTempo.Migracao</b> - Para realizar a migração (criação do banco de dados e popular o banco)  </p>
</li>
<li>
<p>Class Library Domain: <b>DesafioClimaTempo.Repository</b> - Contendo as consultas do banco de dados  </p>
</li>

<li>
<p>Class Library Domain: <b>DesafioClimaTempo.Teste</b> - Projeto de Teste de Unidade (.NET Framework) </p>
</li>
<li>
<p>Aplication Web ASP.NET: <b>DesafioClimaTempo.Web</b> - Contendo a pagina web da previsão do tempo e do candidato  </p>
</li>
</ul>
</p>
<g-emoji class="g-emoji" alias="brain" fallback-src="https://github.githubassets.com/images/icons/emoji/unicode/1f9e0.png">🧠</g-emoji> <b>Desafio</b>
<p>
Breve explicação: Criar um aplicativo web MVC contendo 2 paginas:</p>
<ul dir="auto">
<li>
<p><b>Pagina da previsão do tempo contendo:</b> 3 cidades mais quentes; 3 cidades mais frias; e a previsão do tempo dos próximos 7 dias da cidade selecionado    </p>
</li>
<li><b>Pagina do candidato</b></li>
</ul>
 <p>Os requisitos do desafio foi enviado pela empresa no e-mail.</p>
 
 <g-emoji class="g-emoji" alias="bookmark" fallback-src="https://github.githubassets.com/images/icons/emoji/unicode/1f516.png">🔖</g-emoji><b> Instruções de execução </b>
 <p>Para executar o projeto primeiro precisa configurar a string de conexão do banco de dados o "connectionString" que fica no projeto <b>DesafioClimaTempo.Domain</b> na pasta <b>Context</b> no arquivo <b>EFContext</b>
<p>Após configurar a string de conexão do banco de dados, precisa definir o projeto como Projeto de Inicialização <b>DesafioClimaTempo.Migracao</b>, ele irá criar o banco de dados e também gravar alguns dados fictícios nas tabelas: Cidade, Estado e PrevisaoClima. </p>
<p>Realizado a migração, definir o Projeto de Inicialização <b>DesafioClimaTempo.Web</b>, em seguida pode inicializar o projeto.
