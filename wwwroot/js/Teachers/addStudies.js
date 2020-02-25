$("#addStudies").on("click", () => {
    let html = `
            <fieldset>
                <legend> Ukończone studia </legend>
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <label for="Studies_1__universityName">Nazwa uczelni:</label>
                        <input class="form-control" type="text" data-val="true" data-val-required="Nazwa uczelni jest wymagana." id="Studies_1__universityName" name="Studies[1].universityName" value="" />
                        <span class="text-danger field-validation-valid" data-valmsg-for="Studies[1].universityName" data-valmsg-replace="true"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <label for="Studies_1__fieldOfStudy">Kierunek:</label>
                        <input class="form-control" type="text" data-val="true" data-val-required="Kierunek jest wymagany." id="Studies_1__fieldOfStudy" name="Studies[1].fieldOfStudy" value="" />
                        <span class="text-danger field-validation-valid" data-valmsg-for="Studies[1].fieldOfStudy" data-valmsg-replace="true"></span>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12 col-md-6">
                        <label for="Studies_1__yearOfGraduation">Rok uko&#x144;czenia:</label>
                        <input class="form-control" type="number" data-val="true" data-val-required="Rok urodzenia jest wymagany" id="Studies_1__yearOfGraduation" name="Studies[1].yearOfGraduation" value="" />
                        <span class="text-danger field-validation-valid" data-valmsg-for="Studies[1].yearOfGraduation" data-valmsg-replace="true"></span>
                    </div>
                    <div class="col-sm-12 col-md-6">
                        <label for="Studies_1__academicDegree">Stopie&#x144;:</label>
                        <select class="form-control" data-val="true" data-val-required="Stopie&#x144; studi&#xF3;w jest wymagany" id="Studies_1__academicDegree" name="Studies[1].academicDegree">
                            <option> Wybierz </option>
                            <option value="1"> Studia I stopnia </option>
                            <option value="2"> Studia II stopnia </option>
                            <option value="3"> Studia III stopnia </option>
                        </select>
                        <span class="text-danger field-validation-valid" data-valmsg-for="Studies[1].academicDegree" data-valmsg-replace="true"></span>
                    </div>
                </div>
            </fieldset>`;
    $("#studies").append(html);
});