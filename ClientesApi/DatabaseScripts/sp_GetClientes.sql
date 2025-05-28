CREATE PROCEDURE sp_ObtenerClientesPaginados
    @Page INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.Id, 
        c.Nombre, 
        c.Telefono, 
        p.Nombre AS Pais
    FROM Clientes c
    INNER JOIN Paises p ON c.PaisId = p.Id
    ORDER BY c.Id
    OFFSET (@Page - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END