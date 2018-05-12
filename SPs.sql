USE ProjectsAccounting;  
GO  

CREATE PROCEDURE GetUsers  
AS   
    SET NOCOUNT ON;  
	SELECT *
	FROM
		[ADObjects] grp
		JOIN ADObjectMemberships om ON om.ObjectSID = grp.ObjectSID
		JOIN ADObjects member ON om.MemberObjectSID = member.ObjectSID
	WHERE
		grp.SamAccountName = 'Team Foundation Administrators' and member.objectCategory = 2
GO  