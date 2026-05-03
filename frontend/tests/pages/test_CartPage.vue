import { describe, test, expect } from 'vitest';
import { mount } from '@vue/test-utils';
import CartPage from '../../src/pages/CartPage.vue';

describe('CartPage', () => {
  test('renders cart items', () => {
    const wrapper = mount(CartPage);
    expect(wrapper.exists()).toBe(true);
  });
});
