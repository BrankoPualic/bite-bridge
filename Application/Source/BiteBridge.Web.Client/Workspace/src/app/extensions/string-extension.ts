declare global {
  interface String {
    appendArgument(this: string, ...args: string[]): string;
  }
}

function appendArgument(this: string, ...args: string[]): string {
  return `${this} ${args.join(' ')}`.trim();
}

String.prototype.appendArgument = appendArgument;

export {};
