### 🗂 Estrutura

- **Model** → Classe `Produto` (Id, Descrição, Quantidade, Preço).
- **Helper** → `SQLiteDatabaseHelper` (operações no banco).
- **View** → Interface para exibir/inserir dados.

---

### 🛠 Classe `SQLiteDatabaseHelper`

- Usa `SQLiteAsyncConnection` (assíncrono).
- `readonly` → conexão não pode ser alterada.
- Construtor → cria tabela `Produto` se não existir.

---

### 🔑 Métodos principais

- **Insert(Produto p)** → insere produto. Retorna `int`.
- **Update(Produto p)** → atualiza produto pelo `Id`.
- **Delete(int id)** → exclui produto pelo `Id`. Retorna `int`.
- **GetAll()** → retorna lista de todos os produtos (`SELECT *`).
- **Search(string q)** → busca produtos com `LIKE` na descrição.

---

### 📌 Boas práticas

- Sempre usar **async/await** para não travar a interface.
- Separar responsabilidades (**Model, Helper, View**).
- `CreateTableAsync<T>()` garante que a tabela exista.
- Métodos retornam:
    - `int` → linhas afetadas (Insert, Update, Delete).
    - `List<Produto>` → consultas (GetAll, Search).
