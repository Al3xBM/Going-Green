import * as actionTypes from './actions';


const initialState = {
    isLoggedIn: false
};

const reducer = ( state = initialState, action ) => {
    switch (action.type ) {
        case actionTypes.LOG_IN:
            return {
                ...state,
                isLoggedIn: true
            }
        case actionTypes.LOG_OUT:
            return {
                ...state,
                isLoggedIn: false
            }
        default:
            return state;
    }
};

export default reducer;