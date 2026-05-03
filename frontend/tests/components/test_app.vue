import { expect, test } from 'vitest';
import { mount } from '@vue/test-utils';
import App from '../../src/App.vue';

test('App component renders correctly', () => {
  const wrapper = mount(App);
  expect(wrapper.exists()).toBe(true);
});
