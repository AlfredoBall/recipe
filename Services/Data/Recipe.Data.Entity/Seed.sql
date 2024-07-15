DECLARE @RecipeCNT INT = 0;
DECLARE @IngredientCNT INT = 0;
DECLARE @RecipeID INT = 0;

USE Recipe
WHILE @RecipeCNT < 10
BEGIN
	
	INSERT INTO Recipe (Title) VALUES (CONCAT('Recipe-', @RecipeCNT + 1));
	SELECT @RecipeID = @@IDENTITY;
	SET @RecipeCNT = @RecipeCNT + 1;

	SET @IngredientCNT = 0;

	WHILE @IngredientCNT < 10
	BEGIN
		SET @IngredientCNT = @IngredientCNT + 1;
		INSERT INTO Ingredient ([Text], Recipe_ID) VALUES (CONCAT('Ingredient-', @IngredientCnt), @RecipeID)
		INSERT INTO Instruction ([Order], [Text], Recipe_ID) VALUES (@IngredientCNT, CONCAT('Instruction-', @IngredientCnt), @RecipeID)
	END

	INSERT INTO PlanItem ([Text], [Type]) VALUES (CONCAT('Ingredient-', @RecipeCNT), 0);
	INSERT INTO PlanItem ([Text], [Type]) VALUES (CONCAT('Ingredient-', @RecipeCNT + 10), 1);
END;

INSERT INTO Ingredient ([Text], Recipe_ID) VALUES ('Ingredient-ABC', 1)

SET @RecipeCnt = 0;
SET @IngredientCNT = 0;
SET @RecipeID = 0;

USE Monke
WHILE @RecipeCNT < 10
BEGIN
	
	INSERT INTO Recipe (Title) VALUES (CONCAT('Recipe-', @RecipeCNT + 1));
	SELECT @RecipeID = @@IDENTITY;
	SET @RecipeCNT = @RecipeCNT + 1;

	SET @IngredientCNT = 0;

	WHILE @IngredientCNT < 10
	BEGIN
		SET @IngredientCNT = @IngredientCNT + 1;
		INSERT INTO Ingredient ([Text], Recipe_ID) VALUES (CONCAT('Ingredient-', @IngredientCnt), @RecipeID)
		INSERT INTO Instruction ([Order], [Text], Recipe_ID) VALUES (@IngredientCNT, CONCAT('Instruction-', @IngredientCnt), @RecipeID)
	END

	INSERT INTO PlanItem ([Text], [Type]) VALUES (CONCAT('Ingredient-', @RecipeCNT), 0);
	INSERT INTO PlanItem ([Text], [Type]) VALUES (CONCAT('Ingredient-', @RecipeCNT + 10), 1);
END;

INSERT INTO Ingredient ([Text], Recipe_ID) VALUES ('Ingredient-ABC', 1)