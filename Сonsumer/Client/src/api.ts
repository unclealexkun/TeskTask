import { IBook } from './types/book';

/** Получаем список категорий. */
export async function getBookCategories(): Promise<Array<string>> {
  const api = 'http://localhost:5000/api/categories';
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'GET'
  };
  const response = await fetch(api, options);
  if (response.status === 200) {
    return await response.json();
  }
  throw new Error(`Error: ${response.statusText}`);
}

/** Получить книги по категории.  */
export async function getBooksByCategory(category: string): Promise<Array<IBook>> {
  const api = 'http://localhost:5000/api/book/categories/' + category;
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'GET'
  };
  const response = await fetch(api, options);
  if (response.status === 200) {
    return await response.json();
  }
  throw new Error(`Error: ${response.statusText}`);
}

/** Получить книгу из корзины. */
export async function getBasketBooks(): Promise<Array<IBook>> {
  const api = 'http://localhost:5000/api/basket/';
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'GET'
  };
  const response = await fetch(api, options);
  if (response.status === 200) {
    return await response.json();
  }
  throw new Error(`Error: ${response.statusText}`);
}

/** Добавить книгу в корзину. */
export async function addBasketBook(book: IBook): Promise<boolean> {
  const api = 'http://localhost:5000/api/basket/';
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'POST',
    body: JSON.stringify(book)
  };
  const response = await fetch(api, options);
  if (response.status === 200) {
    return true;
  }
  throw new Error(`Error: ${response.statusText}`);
}

/** Удалить книгу из корзины. */
export async function removeBasketBook(bookId: string): Promise<boolean> {
  const api = 'http://localhost:5000/api/basket/' + bookId;
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'DELETE'
  };
  const response = await fetch(api, options);
  if (response.status === 200) {
    return true;
  }
  throw new Error(`Error: ${response.statusText}`);
}