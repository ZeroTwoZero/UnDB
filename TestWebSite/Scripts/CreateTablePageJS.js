$(function () {
	var serverName = localStorage.getItem("serverName");
	var tableNameInput = $("#tableName");
	var sqlTypes;
	var columnInt = 0;
	$("#column").hide();
	$("#sqlerror").hide();
	$("#sqlsuccess").hide();
	if (!localStorage.getItem("winAuth")) {
		console.log(localStorage.getItem("serverUName"));
		console.log(localStorage.getItem("serverPwd"));
	}
	$.ajax({
		url: '../Handlers/DBSqlTypes.ashx',
		dataType: "json",
		success: function (result, status, xhr) {
			console.log(JSON.stringify(result));
			sqlTypes = result;
		},
		error: function (xhr, status, error) {
			console.log(error);
		},
	});
	$('#addColumn').click(function () {
		$("#column").hide();
		columnInt++;
		var newDiv = $('<div class="columnDiv"><label>Column Name</label><input type="text" class="tableName"><select class="selectOptions" id="sqlTypes'+columnInt+'"></select><button class="deleteButton">Delete Button</button><br><br></div>');
		$('#columnsDiv').append(newDiv);
		$.each(sqlTypes, function (val, text) {
			$("#sqlTypes" + columnInt).append(
				$('<option></option>').val(val).html(text)
			);
		});
	});

	$(document).on("click", ".deleteButton", function (e) {
		$(this).parent().remove();
	});

	$("#createTable").click(function () {
		$("#sqlerror").hide();
		$("#sqlsuccess").hide();
		var tableName = tableNameInput.val();
		var flag = 0;
		var columnNames = [];
		var columnTypes = [];
		$("#column").hide();
		tableNameInput.css({ "border": "1px solid gray" });
		if (tableName.length <= 0) {
			tableNameInput.css({ "border": "1px solid red" });
			flag = 1;
		}
		if ($('#columnsDiv div').length <= 0) {
			$("#column").show();
			flag = 1;
		}
		else {
			$("#columnsDiv div").find("input").each(function () {
				if (($.trim($(this).val()).length <= 0)) {
					$(this).css({ "border": "1px solid red" });
					flag = 1;
				}
			});
		}
		if (flag == 1) {
			return;
		}
		$("#columnsDiv div").find("input").each(function () {
			columnNames.push($.trim($(this).val()));
		});
		$("#columnsDiv div").find("select").each(function () {
			columnTypes.push($.trim($(this).children("option:selected").text()));
		});
		var jsonParam = { TableName: tableName, ColumnNames: columnNames, ColumnTypes: columnTypes }
		$.ajax({
			url: "../Handlers/CreateTableInDB.ashx",
			type: "POST",
			data: JSON.stringify(jsonParam),
			contentType: 'application/json; charset=utf-8',
			success: function (result, xhr, status) {
				if (result == "False") {
					$("#sqlerror").show();
					return;
				}
				$("#sqlsuccess").show();
			},
			error: function (xhr, status, error) {
				$("#sqlerror").show();
			}
		});
	});

	$("#HomePage").click(function () {
		location.href = "HomePage.html";
	});
});