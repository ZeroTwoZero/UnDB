$(function () {
	var WindowsAuthCheckBox = $('input#enableWinAuth');
	var isWinAuth = WindowsAuthCheckBox.prop('checked');
	var testConnDiv = $('#testConn');
	var createTable = $(".button2");
	testConnDiv.hide();
	createTable.prop('disabled', true);

	if (WindowsAuthCheckBox.prop('checked')) {
		$("#serverDet").hide();
	}

	WindowsAuthCheckBox.change(function () {
		if (this.checked) {
			$("#serverDet").hide();
			$(this).prop("checked");
			return;
		}
		$("#serverDet").show();
		createTable.prop("disabled", true);
	});

	$("#checkServer").click(function () {
		var isSucceeded = validateFields();
		if (isSucceeded) {
			$.ajax({
				url: '../Handlers/DBConnectionChecker.ashx',
				contentType: "application/json; charset=utf-8",
				data: {
					sName: $("#serverName").val(),
					sDB: $("#dbName").val(),
					sUName: $("#serverUName").val(),
					sPwd: $("#serverPwd").val(),
					winAuth: WindowsAuthCheckBox.prop('checked'),
				},
				success: function (result, status, xhr) {
					console.log("Your Response is: " + result);
					if (result == "True") {
						testConnDiv.show();
						createTable.prop('disabled', false);
					}
				},
				error: function (xhr, status, error) {
					console.log(error);
				},
			});
		}
	});

	$("#goToCreateTable").click(function () {
		SaveSeverDetailsInLocalStorage();
		window.location.href = "Create_Table.html";
	});

	$("#goToUpdateTable").click(function () {
		SaveSeverDetailsInLocalStorage();
		window.location.href = "Update_Table_Page.html";
	});

	$("#goToDeleteTable").click(function () {
		SaveSeverDetailsInLocalStorage();
		window.location.href = "Delete_Table_Page.html";
	});

	$(document).on("input", ".serverValue", function () {
		createTable.prop("disabled", true);
	});

	function validateFields() {
		testConnDiv.hide();
		createTable.prop('disabled', true);
		var serverNameInput = $("#serverName");
		var serverUNameInput = $("#serverUName");
		var serverPwdInput = $("#serverPwd");
		var serverDBInput = $("#dbName");
		var serverName = serverNameInput.val();
		var serverUName = serverUNameInput.val();
		var serverPwd = serverPwdInput.val();
		var serverDB = serverDBInput.val();
		isWinAuth = WindowsAuthCheckBox.prop('checked');
		serverNameInput.css({ "border": "1px solid gray" });
		serverUNameInput.css({ "border": "1px solid gray" });
		serverPwdInput.css({ "border": "1px solid gray" });
		serverDBInput.css({ "border": "1px solid gray" });
		if (isWinAuth) {
			if (serverDB.length == 0) {
				serverDBInput.css({ "border": "1px solid red" });
			}
			if (serverName.length == 0) {
				serverNameInput.css({ "border": "1px solid red" });
			}
		}
		else {
			if (serverName.length == 0) {
				serverNameInput.css({ "border": "1px solid red" });
			}
			if (serverUName.length == 0) {
				serverUNameInput.css({ "border": "1px solid red" });
			}
			if (serverPwd.length == 0) {
				serverPwdInput.css({ "border": "1px solid red" });
			}
		}
		if ((!isWinAuth && serverName.length > 0 && serverUName.length > 0 && serverPwd.length > 0) || (isWinAuth && serverName.length > 0 && serverDB.length > 0)) {
			
			return true;
		}
		return false;
	}

	function SaveSeverDetailsInLocalStorage() {
		localStorage.setItem("serverName", $("#serverName").val());
		localStorage.setItem("serverDBName", $("#dbName").val());
		localStorage.setItem("winAuth", WindowsAuthCheckBox);
		if (!WindowsAuthCheckBox) {
			localStorage.setItem("serverUName", $("#serverUName").val());
			localStorage.setItem("serverPwd", $("#serverPwd").val());
		}
    }
});