import { describe, test, expect } from 'vitest';
import { mount } from '@vue/test-utils';
import ProductsPage from '../../src/pages/ProductsPage.vue';

describe('ProductsPage', () => {
  test('renders product list', () => {
    const wrapper = mount(ProductsPage);
    expect(wrapper.exists()).toBe(true);
  });
});
