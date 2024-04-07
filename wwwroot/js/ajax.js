// phân quyền cho tài khoản
function SaveGrantPermissions(UserId, RoleId) {
    var jsonData = {
        UserId : UserId,
        RoleId: RoleId
    }
    $.ajax({
        url: '/Admin/User/GrantPermissions',
        type: 'post',
        data: jsonData,
        dataType: 'JSON',
        success: function (data) {
            alert(data.status);
        }
    })
}
