import { IAuthor } from "./author";

/** Книга. */
export interface IBook {
  /** Идентификатор книги. */
  Id: string;
  /** Заголовок. */
  Title: string;
  /** Раздел. */
  Category: string;
  /** Авторы. */
  Authors: IAuthor[];
  /** Дата публикации. */
  PublicationDate: number;
  /** Язык, на котором написана книга. */
  Language: string;
  /** Количество страниц */
  Pages: number;
  /** Возрастной лимит. */
  AgeLimit: number;
  /** Путь до изображения товара. */
  PathToPhoto: string;
}