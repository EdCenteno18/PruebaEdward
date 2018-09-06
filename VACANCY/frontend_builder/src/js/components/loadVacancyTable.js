export const loadVacancyTable = () => {

    $('#check1').change(function(){
        if ($(this).is(':checked')) {
            $('.main-container__btn-create-vacancy').removeClass('disabled');
        }else{
            $('.main-container__btn-create-vacancy').addClass('disabled');
        }
    });
    $('#load-vacancy').footable();
};