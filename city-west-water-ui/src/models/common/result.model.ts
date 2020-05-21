export interface IResult {
    isSuccess: boolean;
    errors: Array<string>;
  }

export interface IValuedResult<T> extends IResult {
value: T;
}
  