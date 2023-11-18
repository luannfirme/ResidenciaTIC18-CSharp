<h3 align="left">INSTRUÇÃO PRÁTICA</h3>
<br>
<p align="left"><b>1.</b> Como você pode verificar se o .NET SDK está corretamente instalado em
seu sistema? Em um arquivo de texto ou Markdown, liste os comandos que podem
ser usados para verificar a(s) versão(ões) do .NET SDK instalada(s), como remover e
atualizar.</p>
<br>
<p align="left"><b>R:</b> Os comandos podem ser:</p>
<ul>
<li>dotnet --version = Para verificar a versão instalada</li>
<li>dotnet --list-sdks = Para listar todos os SDKs instalados</li>
<li>dotnet sdk uninstall "sua versão" = Para desinstalar o SDK instalado, sendo especificado a versão caso tenha mais de uma</li>
<li>dotnet tool update --global dotnet = Para atualizar o SDK</li>
</ul>
<br>
<br>
<p align="left"><b>2.</b> Quais são os tipos de dados numéricos inteiros disponíveis no .NET? Dê
exemplos de uso para cada um deles através de exemplos.</p>
<br>
<p align="left"><b>R:</b> São eles:</p>
<table>
<thead>
<tr>
<th>Tipo</th>
<th>Intervalo</th>
</tr>
</thead>
<tbody>
<tr>
<td>sbyte</td>
<td>-128 a 127</td>
</tr>
<tr>
<td>byte</td>
<td>0 a 255</td>
</tr>
<tr>
<td>short</td>
<td>-32.768 a 32.767</td>
</tr>
<tr>
<td>ushort</td>
<td>0 a 65.535</td>
</tr>
<tr>
<td>int</td>
<td>-2.147.483.648 a 2.147.483.647</td>
</tr>
<tr>
<td>uint</td>
<td>0 a 4.294.967.295</td>
</tr>
<tr>
<td>long</td>
<td>-9.223.372.036.854.775.808 a 9.223.372.036.854.775.807</td>
</tr>
<tr>
<td>ulong</td>
<td>0 a 18.446.744.073.709.551.615</td>
</tr>
<tr>
<td>nint</td>
<td>Depende da plataforma (computada em runtime)</td>
</tr>
<tr>
<td>nuint</td>
<td>Depende da plataforma (computada em runtime)</td>
</tr>
</tbody>
</table>
<br>
Os Exemplos foram inserido no program.cs
<br>
<h4>Referências:</h4>
https://learn.microsoft.com/pt-br/dotnet/core/tools/dotnet
<br>
https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/builtin-types/integral-numeric-types