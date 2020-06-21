$(function () {
	$("#sqlerror").hide();
	$("#sqlsuccess").hide();
	sqlTableNames = []
	$.ajax({
		url: '../Handlers/GetTableNamesFromDB.ashx',
		dataType: "json",
		success: function (result, status, xhr) {
			console.log(JSON.stringify(result));
			sqlTableNames = result;
			$.each(sqlTableNames, function (val, text) {
				$("#tableSelector").append(
					$('<option></option>').val(val).html(text)
				);
			});
		},
		error: function (xhr, status, error) {
			console.log(error);
		},
	});
	$("#deleteButton").click(function () {
		$("#sqlerror").hide();
		$("#sqlsuccess").hide();
		$.ajax({
			url: '../Handlers/DeleteTableInDB.ashx',
			contentType: "application/json; charset=utf-8",
			data: {
				tName: $("#tableSelector").children("option:selected").text(),
			},
			success: function (result, status, xhr) {
				console.log("Your Response is: " + result);
				if (result == "True") {
					$("#sqlsuccess").show();
					return;
				}
				$("#sqlerror").show();
			},
			error: function (xhr, status, error) {
				console.log(error);
			},
		});
    });
});