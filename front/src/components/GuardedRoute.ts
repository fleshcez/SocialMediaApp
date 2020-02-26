export interface GuardedRouteProps {
    canNavigate: () => boolean;
    onSuccess: () => JSX.Element;
    onFail: () => JSX.Element;
    debugString?: string;
}

export function GuarderRoute({
    canNavigate,
    onFail,
    onSuccess,
    debugString
}: GuardedRouteProps) {
    const retVal = canNavigate() ? onSuccess() : onFail();
    console.log(retVal);
    return retVal;
}
