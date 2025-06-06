CREATE TABLE [dbo].[PokemonTypes]
(
    PokemonID  INT PRIMARY KEY IDENTITY(1,1),
    TypeIDOne INT NOT NULL,
    TypeIDTwo INT NOT NULL,

    CONSTRAINT FK_PokemonTypes_Type1 FOREIGN KEY (TypeIDOne) REFERENCES Types(Id),
    CONSTRAINT FK_PokemonTypes_Type2 FOREIGN KEY (TypeIDTwo) REFERENCES Types(Id)
);
