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
//function SubmitForm(genderId) {
//    const form = document.getElementById(genderId);
//    form.submit();
//}

//$('input [type="checkbox"] [name="gender"]').on('change', function () {
//    var selectedGender = $('input[type="checkbox"] [name="gender"]: checked').map(function () {
//        return $(this).val();
//    }).get();

//    $.ajax({
//        url: '/Doctor/GetFilteredDoctor',
//        type: 'POST',
//        dataType: 'html',
//        data: {
//            gender: selectedGender
//        }，
//        success: function (result) {
//            $("#doctor-list").html(result);
//        },
//        error: function () {
//            console.log('An error occurred while retrieving filtered product data.');
//        }
//    });
//});



