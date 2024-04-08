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
function submitImage() {
    const result = confirm("Bạn muốn đổi ảnh đại diện?");

    if (result) {
        // Cách 2: Gọi trực tiếp submit() trên biểu mẫu
        const form = document.getElementById('profile-form');
        form.submit();
    } else {
        // Nút "Cancel" được nhấp
        // Không làm gì
    }
}
