const ELevels = {
    Junior: 0,
    Medium: 1,
    Advanced: 2,
    Senior: 3, 
}

function getLabel(value, type) {
    if (type == "ELevels") {
        switch (value) {
            case ELevels.Junior:
                return 'Consultant Junior';
            case ELevels.Medium:
                return 'Consultant ';
            case ELevels.Advanced:
                return 'Advanced Consultant';
            case ELevels.Senior:
                return 'Senior Consultant';
            default:
                return null;
        }
    }
}

function enumToArray(enumObject, type) {
    let all = [];
    for (let key in enumObject) {
        let obj = {
            id: enumObject[key],
            label: getLabel(enumObject[key], type)
        };
        all.push(obj);
    }
    return all;
}